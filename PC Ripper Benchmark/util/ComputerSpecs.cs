﻿using Microsoft.Win32;
using System;
using System.Diagnostics;

namespace PC_Ripper_Benchmark.util {

    /// <summary>
    /// The <see cref="ComputerSpecs"/> class.
    /// <para></para>Represents this particular pro
    /// Author: Anthony Jaghab (c), all rights reserved.
    /// </summary>

    public class ComputerSpecs {

        private Process process;
        private string path;

        public ComputerSpecs() {

        }

        /// <summary>
        /// not implemented.
        /// </summary>
        /// <param name="process"></param>
        /// <param name="path"></param>

        private void CreateProcess(out Process process, string path) {

            throw new NotImplementedException("Did not verify this.");

            process = new Process {
                EnableRaisingEvents = true
            };

            process.StartInfo.UseShellExecute = false;
            process.StartInfo.FileName = "msinfo32.exe";
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.Arguments = $"/report {path}";
            process.StartInfo.WorkingDirectory = path;
            process.Start();
            process.WaitForExit();
            process.Close();
        }

        /// <summary>
        /// Creates a <see cref="SaveFileDialog"/> and
        /// checks if the path exists, returns true or false.
        /// </summary>
        /// <param name="path">Returns a path if a file path 
        /// is valid. Otherwise null</param>
        /// <returns></returns>

        public bool SetDirectory(out string path) {

            // might be a open directory dialog because we want to 
            SaveFileDialog saveFile = new SaveFileDialog {
                InitialDirectory = Environment.CurrentDirectory,
                RestoreDirectory = true,
                Filter = "Text File (.txt)|*.txt|System Information File (.nfo)|*.nfo|All files (.)|*.",
                DefaultExt = "txt",
            };

            if (saveFile.ShowDialog() == true) {
                path = saveFile.FileName;
                return true;
            }

            path = null;
            return false;
        }


    }

}

