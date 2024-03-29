﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Solarsplash_Dataviewer.Models.RunElements;

namespace Solarsplash_Dataviewer.Models
{
    public interface IRunDataRepository
    {
        /// <summary>
        /// Returns a fully initialized RunData object.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        RunData Get_RunData_object(string name);

        /// <summary>
        /// Returns the RunData object from database without any sub objects loaded except for the datalabels
        /// </summary>
        /// <param name="name">Run name</param>
        /// <returns></returns>
        RunData Get_RunData_base_object(string name);

        bool Delete_RunData_object(RunData item);

        /// <summary>
        /// Finds run that has specified name and addeds given RunElement to it. If no RunData object is found a new one will be created.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        bool Add_RunElement_to_RunData(string name, RunElement element);

        /// <summary>
        /// Makes new run in the database. If there is a run with the same name already there append "_DUP" to end and retries add.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="labels"></param>
        void Add_New_Run(string name, List<DataLabel> labels);
    }
}
