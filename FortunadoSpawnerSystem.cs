using System;
using System.Collections.Generic;
using XRL.World;
using XRL.World.Parts;
using XRL.World.ZoneBuilders;

namespace XRL
{
  [Serializable]
  public class Gearlink_CASKOFROSEWINE_FortunadoSpawnerSystem : IGameSystem
  {
    public bool spawned = false;

    public int chance = 1;

    [NonSerialized]
    public Dictionary<string, bool> Visited = new Dictionary<string, bool>();

    public override void ZoneActivated(Zone zone) => this.CheckFortunadoSpawn(zone);

    public override void LoadGame(SerializationReader Reader) => this.Visited = Reader.ReadDictionary<string, bool>();

    public override void SaveGame(SerializationWriter Writer) => Writer.Write<string, bool>(this.Visited);

    public void CheckFortunadoSpawn(Zone zone)
    {
      /* Don't spawn if above ground. Z = 10 is the surface of the world and
      Z < 10 is in the sky. */
      if ( this.spawned || zone.IsWorldMap() || zone.Z <= 10 || this.Visited.ContainsKey(zone.ZoneID))
        return;

      this.Visited.Add(zone.ZoneID, true);

      if (chance.in100())
      {
        new Gearlink_CASKOFROSEWINE_FortunadoSpawnerBuilder().BuildZone( zone );
        this.spawned = true;
      }
    }
	}
}
