using System.Collections.Generic;

namespace EmptyTank
{
    [KSPAddon(KSPAddon.Startup.EditorAny, false)]
    public class EmptyTank
    {
        private static List<Part> vessel;
        public static void EmptyTanks()
        {
            vessel = EditorLogic.SortedShipList;
            foreach (Part part in vessel)
            {
                foreach (var res in part.Resources)
                {
                    res.amount = 0;
                }
            }
        }

        public static void FillTanks()
        {
            vessel = EditorLogic.SortedShipList;
            foreach (Part part in vessel)
            {
                foreach (var res in part.Resources)
                {
                    res.amount = res.maxAmount;
                }
            }
        }
    }
}