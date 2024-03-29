﻿// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using System.Reflection;
using System.Text;
using CliCommandParser.Contracts;

namespace CliCommandParser;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class CliParser : ICliParser {
    private readonly Dictionary<string, Action<string[]>> _flagToActionMap = new();
    private readonly Dictionary<string, string?> _descriptions = new();
    private IReadOnlyDictionary<string, string?> Descriptions => _descriptions.AsReadOnly(); // Again added for the future, don't know what to add to it.
    
    // -----------------------------------------------------------------------------------------------------------------
    // Constructor
    // -----------------------------------------------------------------------------------------------------------------
    public CliParser() {
        // There is one reserved command "HELP", which lists all command
        _flagToActionMap.Add("help", HelpCommand);
        _descriptions.Add("help", "Display all Commands");
    }
    
    // -----------------------------------------------------------------------------------------------------------------
    // Methods
    // -----------------------------------------------------------------------------------------------------------------
    public ICliParser RegisterFromCliAtlas<T>(IEnumerable<T> cliCommandAtlas, bool force = false) where T : ICliCommandAtlas {
        foreach (var atlas in cliCommandAtlas) {
            RegisterFromCliAtlas(atlas);
        }
        return this;
    }
    public ICliParser RegisterFromCliAtlas<T>(T cliCommandAtlas, bool force = false) where T:ICliCommandAtlas{
        var methods = typeof(T).GetMethods(BindingFlags.Public | BindingFlags.Instance);

        foreach (var methodInfo in methods) {
            // Quick exits to find the correct methods
            if (methodInfo.GetCustomAttributes().FirstOrDefault(a => a is ICliCommandAttribute) is not ICliCommandAttribute cliCommandAttribute) continue;
            var methodParameters = methodInfo.GetParameters();
            if (methodParameters.Length == 0) continue;
            
            var openDelegateType = typeof(Action<>); // Why does this need to be an empty action???
            var delegateType = openDelegateType.MakeGenericType(methodParameters[0].ParameterType); // DON'T use IParameterOptions, it doesn't work!
            Delegate del = Delegate.CreateDelegate(delegateType, cliCommandAtlas, methodInfo);

            string commandName = cliCommandAttribute.Name.ToLower();
            
            // We don't do anything with the success value,
            //      just slap it into the if statement
            //      Oh and add the description here, instead of the older above version (works better with the errors)
            if (_flagToActionMap.TryAdd(
                    commandName,
                    args => { del.DynamicInvoke(cliCommandAttribute.GetParameters(args)); }
            )) {
                _descriptions.Add(commandName, cliCommandAttribute.Description);
                continue;
            }
            
            // if something fails
            //      Don't write the same string twice
            string errorText = $"command '{commandName}' could not be bound to method '{typeof(T)}.{methodInfo.Name}'"; 
            if (!force) {
                Console.WriteLine($"Ignoring: {errorText}");
            } else {
                throw new Exception(errorText);
            }
        }

        // added for easy chaining
        return this;
    }

    public bool TryParse(IEnumerable<string> args, bool parseMutliple) {
        if (!parseMutliple) {
            return TryParse(args);
        }
        
        List<List<string>> resultLists = [];
        int startIndex = 0;
        var enumerable = args as List<string> ?? args.ToList();
        var length = enumerable.Count;

        for (int i = 0; i < length; i++) {
            if (!enumerable[i].Equals("&&")) continue;
            
            // Add the sublist from startIndex to i to the resultLists
            resultLists.Add(enumerable.GetRange(startIndex, i - startIndex));
            startIndex = i + 1;
        }

        // Add the last sublist if there's any remaining elements
        if (startIndex < length) {
            resultLists.Add(enumerable.GetRange(startIndex, length - startIndex));
        }

        foreach (var argsSplit in resultLists) {
            TryParse(argsSplit);
        }

        return true;
    }
    
    public bool TryParse(IEnumerable<string> args) {
        var enumerable = args as string[] ?? args.ToArray();
        
        if (!_flagToActionMap.TryGetValue(enumerable[0].ToLower(), out var action)) return false;
        action(enumerable[1..]); // Strip out the command and keep the arguments
        return true;
    }
    
    // TODO test this out
    public ICliParser RegisterFromDlLs(IEnumerable<string> filePaths) {
        foreach (var filePath in filePaths) {
            Assembly assembly = Assembly.LoadFrom(filePath);

            foreach (var objectType in assembly.GetTypes()) {
                if (!typeof(ICliCommandAtlas).IsAssignableFrom(objectType)
                    || objectType is not { IsInterface: false, IsAbstract: false }) continue;

                // Actually register the commands
                ICliCommandAtlas? cliCommandAtlas = (ICliCommandAtlas?)Activator.CreateInstance(objectType);

                if (cliCommandAtlas is null) {
                    // Something went wrong
                    throw new Exception($"Command atlas '{objectType}' could not be imported from : '{filePath}'");
                }

                RegisterFromCliAtlas(cliCommandAtlas);
            }
        }

        // added for easy chaining
        return this;
    }

    // -----------------------------------------------------------------------------------------------------------------
    // Default Command(s)
    // -----------------------------------------------------------------------------------------------------------------
    public void HelpCommand(string[] _) {
        int maxCommandNameLength = Math.Max(
            Descriptions.Keys.Select(k => k.Length).Max(), 
            12 // always have at least 12 as padding value
        ); 
        string title = "Command Name".PadRight(maxCommandNameLength);
        string pattern = new string('-', maxCommandNameLength);

        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine($"{title} | Description");
        stringBuilder.AppendLine($"{pattern}-|------------");
            
        foreach ((string name, string? desc) in Descriptions) {
            stringBuilder.AppendLine($"{name.PadRight(maxCommandNameLength)} | {desc}");
        }
            
        Console.WriteLine(stringBuilder);
    }

}