using System;
using System.Collections.Generic;
using System.IO;

namespace CodeGenerator
{
    public class Program
    {
        public static string FilePath = @"C:\Users\adenh\source\repos\Prominence\CodeGenerator\bin\Debug\net5.0\code.cs";
        public static List<string> Frames = new List<string>() {
            "Entrance",
            "HeadTowardsClosedDoor",
            "InvestigateVent",
            "HopOntoDesk",
            "ClimbThroughVent",
            "FollowBloodTrail",
            "RecoveryRoomBase",
            "InspectTheFeral",
            "InspectTheFeral2",
            "InspectTheFeral3",
            "InspectRecoveryRoom",
            "InvestigateControlPanel",
            "EjectTheBattery",
            "MachinePowered",
            "PowerMachineByHand",
            "PowerMachineByHandFail",
            "PowerMachineByHandFail2",
            "ConfigureMachine",
            "ConfigureMachine2",
            "ConfigureMachine3",
            "ConfigureMachine4",
            "MachineRunning",
            "MachineSuccess",
            "MachineFailure",
            "InvestigateTextBooks",
            "ReadManual",
            "ReadManual2",
            "ReadManual3",
            "InvestigateFeralSuccess",
            "InvestigateFeralFail",
        };

        static void Main(string[] args)
        {
            
            using (StreamWriter writer = new StreamWriter(FilePath))
            {
                WriteFrameProperiesToFile(writer, Frames);
                WriteFrameAssignmentToFile(writer, Frames);
                WriteFrameDictionaryToFile(writer, Frames);
                WriteFrameInitializationsToFile(writer, Frames);
            }
            
        }

        public static void WriteFrameProperiesToFile(StreamWriter writer, List<string> frames)
        {
            foreach (var frame in frames)
            {
                writer.WriteLine($"public static FrameModel {frame};");
            }
        }

        public static void WriteFrameAssignmentToFile(StreamWriter writer, List<string> frames)
        {
            foreach (var frame in frames)
            {
                writer.WriteLine($"{frame} = new FrameModel(Film, Act, Scene, {frame}, Constants.RecoveryRoom);");
            }
        }

        public static void WriteFrameDictionaryToFile(StreamWriter writer, List<string> frames)
        {
            writer.WriteLine("Frames = new Dictionary<string, FrameModel>() {");
            foreach (var frame in frames)
            {
                writer.WriteLine($"{{{frame}.Name,{frame}}},");
            }
            writer.WriteLine("};");
        }

        public static void WriteFrameInitializationsToFile(StreamWriter writer, List<string> frames)
        {
            foreach (var frame in frames)
            {
                writer.WriteLine($"InitialiseHearSound({frame});");
            }
        }
    }
}
