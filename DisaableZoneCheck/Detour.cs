using System;

using System.Reflection;

namespace DisableZoneCheck
{

    /// <summary>
    ///This detours the CheckCollidingBuildngs method in BuildingTool. Its based on boformers Larger Footprints mod. Many thanks to him for his work. 
    /// </summary>


    public class ZoneCheckDetour
    {
        private static bool deployed = false;


        private static RedirectCallsState _Building_CheckZoning_state;
        private static MethodInfo _Building_CheckZoning_original;
        private static MethodInfo _Building_CheckZoning_detour;

        public static void Deploy()
        {

            if (!deployed)
            {

                _Building_CheckZoning_original = typeof(Building).GetMethod(
                    "CheckZoning",
                    BindingFlags.Instance | BindingFlags.Public,
                    null,
                    new Type[] { typeof(ItemClass.Zone), typeof(ItemClass.Zone), typeof(bool) },
                    null
                );

                _Building_CheckZoning_detour = typeof(ZoneCheckDetour).GetMethod(
                    "CheckZoning",
                    BindingFlags.Instance | BindingFlags.Public,
                    null,
                    new Type[] { typeof(ItemClass.Zone), typeof(ItemClass.Zone), typeof(bool) },
                    null
                );

                _Building_CheckZoning_state = RedirectionHelper.RedirectCalls(_Building_CheckZoning_original, _Building_CheckZoning_detour);


                deployed = true;

                //Debug.Log("BuildingTool Methods detoured");
            }
        }

        public static void Revert()
        {

            if (deployed)
            {

                RedirectionHelper.RevertRedirect(_Building_CheckZoning_original, _Building_CheckZoning_state);
                _Building_CheckZoning_original = null;
                _Building_CheckZoning_detour = null;


                deployed = false;

                //Debug.Log("BuildingTool Methods restored");
            }
        }


        public bool CheckZoning(ItemClass.Zone zone1, ItemClass.Zone zone2, bool allowCollapsed)
        {
            //Its always true!
            return true;

        }


    }
}
