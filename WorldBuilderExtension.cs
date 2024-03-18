using Genkit;
using XRL.World;
using XRL.World.Parts;

namespace XRL.World.WorldBuilders
{
  [JoppaWorldBuilderExtension]
  public class Gearlink_CASKOFROSEWINE_WorldBuilderExtension : IJoppaWorldBuilderExtension
  {
    /* This builder is only ever going to be modifying JoppaWorld, the main world
    seen on the overworld map. */
    private string World = "JoppaWorld";

    // The game calls this method after JoppaWorld generation takes place.
    // JoppaWorld generation includes the creation of lairs, historic ruins, villages, and more.
    public override void OnAfterBuild(JoppaWorldBuilder builder)
    {
      // Will log to the Player.log so you know that this builder extension is working.
      MetricsManager.LogInfo("Gearlink_CASKOFROSEWINE_WorldBuilderExtension running");

      // Get a mutable zone in the Ruins terrain.
			Location2D location = builder.popMutableLocationOfTerrain("Ruins");
      // Get that zone's ID.
			string zoneID = Zone.XYToID(this.World, location.X, location.Y, 10);
      /* Add the FortunadoSpawnerBuilder to the chosen zone so that it will build
      the Fortunado encounter when the zone is loaded instead of at world gen. */
      The.ZoneManager.AddZoneBuilder(
        zoneID,
        ZoneBuilderPriority.AFTER_TERRAIN,
        "Gearlink_CASKOFROSEWINE_FortunadoSpawnerBuilder"
      );

      /* Will log the ID of the zone being modified to the Player.log for debugging
      purposes. In game, you can use the wish goto:zoneID to teleport to the zone
      the builder modified. */
			MetricsManager.LogInfo( zoneID );
    }
	}
}
