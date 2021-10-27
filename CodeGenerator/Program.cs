﻿using System;
using System.Collections.Generic;
using System.IO;

namespace CodeGenerator
{
    public class Program
    {
        public static string FilePath = @"C:\Users\adenh\source\repos\Prominence\CodeGenerator\bin\Debug\net5.0\code.cs";
        public static List<string> Frames = new List<string>() {
            "Entrance",
            "Introduction",
            "WhatIsHappeningHere",
            "WhatAreThoseCreatures",
            "HandOverAccessCard",
            "HandOverAccessCard2",
            "RestoringSystems",
            "PeerOutTheViewPort",
            "InspectTheRoom",
            "TalkToSteinmann",
            "TalkToSteinmann2",
            "GiveSpareMagazine",
            "ExamineTerminal",
            "LogEntry1",
            "LogEntry2",
            "LogEntry3",
            "CalculateTrajectory",
            "ShowJanTrajectory",
            "WhatsGoingOn",
            "TurnOnShipLight",
            "SeaCreatureGroan",
            "KillTheLights",
            "WhatWillWeDo",
            "WhatHappensToTheFerals",
            "ActivateEvacuationProtocol",
            "ActivateEvacuationProtocol2",
            "ActivateEvacuationProtocol3",
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
                writer.WriteLine($"{frame} = new FrameModel(Film, Act, Scene, \"{frame}\", Constants.Black);");
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
                writer.WriteLine($"Initialise{frame}({frame});");
            }
        }
    }
}
