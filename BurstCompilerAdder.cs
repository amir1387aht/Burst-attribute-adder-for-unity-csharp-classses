using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

public class BurstCompilerAdder : MonoBehaviour
{
    [MenuItem("Tools/Burst/Add Burst Attribute To All classes")]
    public static void ConvertClasses()
    {
        ProcessDirectory(Application.dataPath + "/Scripts");
    }

    private static void ProcessDirectory(string directoryPath)
    {
        DirectoryInfo dirInfo = new DirectoryInfo(directoryPath);
        FileInfo[] files = dirInfo.GetFiles("*.cs");

        foreach (FileInfo file in files)
            ProcessFile(file);

        DirectoryInfo[] subDirectories = dirInfo.GetDirectories();

        foreach (DirectoryInfo subDirectory in subDirectories)
            ProcessDirectory(subDirectory.FullName);
    }

    private static void ProcessFile(FileInfo file)
    {
        string text = File.ReadAllText(file.FullName);
        string[] lines = text.Split('\n');

        bool hasBurstUsing = lines.Any(line => line.Contains("using Unity.Burst;"));
        bool hasBurstCompile = lines.Any(line => line.Contains("[BurstCompile]"));

        if (!hasBurstUsing) text = "using Unity.Burst;\n" + text;

        if (!hasBurstCompile)
            text = Regex.Replace(text, @"(public|private|abstract|sealed|partial)?\s*class\s+(\w+)", "[BurstCompile]\n$0");

        File.WriteAllText(file.FullName, text);
    }
}