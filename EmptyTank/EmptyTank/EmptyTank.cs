using System.Collections.Generic;

namespace EmptyTank
{
    [KSPAddon(KSPAddon.Startup.EditorAny, false)]
    public class EmptyTank
    {
        /// <summary>
        /// The active vessel stored as a List of parts
        /// </summary>
        private static List<Part> vessel;

        public static void EmptyTanks()
        {
            // Update the parts list of the vessel
            vessel = EditorLogic.SortedShipList;
            // Loop through all parts in the vessel
            foreach (Part part in vessel) 
            {
                // Loop through all resources in the part and set its amount to 0
                foreach (var res in part.Resources) 
                {
                    res.amount = 0;
                }
            }
        }

        public static void FillTanks()
        {
            // Update the parts list of the vessel
            vessel = EditorLogic.SortedShipList;
            // Loop through all parts in the vessel
            foreach (Part part in vessel)
            {
                // Loop through all resources in the part and set its amount to the max it can hold
                foreach (var res in part.Resources)
                {
                    res.amount = res.maxAmount;
                }
            }
        }
    }
}
