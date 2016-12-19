using System.Linq;
using ICities;
using ColossalFramework.Plugins;
using System;

namespace DisableZoneCheck
{

    public class Loading : LoadingExtensionBase
    {


        public override void OnLevelLoaded(LoadMode mode)
        {
            base.OnLevelLoaded(mode);

            if (mode != LoadMode.LoadGame && mode != LoadMode.NewGame)
                return;

            ZoneCheckDetour.Deploy();

        }

    
        public override void OnReleased()
        {
            ZoneCheckDetour.Revert();
            base.OnReleased();
        }
    }
}