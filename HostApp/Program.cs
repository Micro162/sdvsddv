using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace HostApp
{
    internal static class DynamicLoader
    {
     
        public static string FindDll(string dllFileName, string projectFolderName)
        {
            string? dir = AppContext.BaseDirectory;

            while (dir != null)
            {
                string candidate = Path.Combine(dir, projectFolderName);
                if (Directory.Exists(candidate))
                {
                    string? found = Directory
                        .GetFiles(candidate, dllFileName, SearchOption.AllDirectories)
                        .OrderByDescending(File.GetLastWriteTimeUtc)
                        .FirstOrDefault();

                    if (found != null)
                        return found;
                }

                DirectoryInfo? parent = Directory.GetParent(dir);
                dir = parent?.FullName;
            }

            throw new FileNotFoundException(
                $"Не вдалося знайти {dllFileName}. Переконайтеся, що проєкт {projectFolderName} зібрано (Build).");
        }

        public static Assembly LoadAssembly(string dllPath)
        {
            if (!File.Exists(dllPath))
                throw new FileNotFoundException($"DLL не знайдено: {dllPath}");

            return Assembly.LoadFrom(dllPath);
        }

        public static object? InvokeStatic(
            Assembly assembly,
            string typeFullName,
            string methodName,
            Type[]? parameterTypes,
            params object[] args)
        {
            Type? type = assembly.GetType(typeFullName)
                ?? throw new TypeLoadException($"Тип '{typeFullName}' не знайдено у збірці {assembly.FullName}.");

            MethodInfo? method = parameterTypes == null
                ? type.GetMethod(methodName, BindingFlags.Public | BindingFlags.Static)
                : type.GetMethod(methodName, BindingFlags.Public | BindingFlags.Static, binder: null, types: parameterTypes, modifiers: null);

            if (method == null)
                throw new MissingMethodException($"Метод '{methodName}' не знайдено у типі '{typeFullName}'.");

            return method.Invoke(null, args);
        }
    }
}