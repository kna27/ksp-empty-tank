using System;
using System.Collections.Generic;
using UnityEngine;

namespace EmptyTank
{
    [KSPAddon(KSPAddon.Startup.EditorAny, false)]
    public class EmptyTank
    {
        private static List<Part> vessel;
        public static void EmptyTanks()
        {
            ScreenMessages.PostScreenMessage("emptied");

            foreach (Part part in vessel)
            {
                Console.WriteLine(part);
                ScreenMessages.PostScreenMessage(part);
            }
        }

        public static void FillTanks()
        {
            ScreenMessages.PostScreenMessage("filled");
        }

        void Update()
        {
            vessel = EditorLogic.SortedShipList;
        }
    }
}