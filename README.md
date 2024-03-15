# Burst Compiler Adder

This Unity script automatically adds the `using Unity.Burst;` directive and the `[BurstCompile]` attribute to all C# scripts in a specified directory and its subdirectories.

## How It Works

The script uses the `System.IO` namespace to access the file system and find all C# scripts in the specified directory. It then reads each file and checks if it already contains the `using Unity.Burst;` directive and the `[BurstCompile]` attribute. If not, it adds them.

The script is added as a menu item in the Unity editor under `Tools > Burst > Add Burst Attribute To All classes`. When you select this menu item, it processes all C# scripts in the `Application.dataPath + "/Scripts"` directory.

## Usage

1. Place this script in an Editor folder in your Unity project.
2. From the Unity editor, click on `Tools > Burst > Add Burst Attribute To All classes`.
3. The script will process all C# scripts in the `Application.dataPath + "/Scripts"` directory and its subdirectories.

## Note

Please make sure to backup your scripts before running this script as it modifies the original files.
If your project script folder has diffrent name, update it in code

## Disclaimer

This script is provided as is without any guarantees or warranty. The author is not responsible for any damage or data loss that may occur from using this script. Use at your own risk.
