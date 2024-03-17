using System;

namespace XRL.World.Parts
{
  /* This class is basically copied from the XRL.World.Parts.RecorporealizationBoothSpawner
  part which is used to spawn the recoming nook Gyl somewhere in Lake Hinnom. */
  [Serializable]
  public class Gearlink_CASKOFROSEWINE_FortunadoSpawner : IPart
  {
    public override bool AllowStaticRegistration() => true;

    public override void Register(GameObject Object)
    {
      Object.RegisterPartEvent((IPart) this, "EnteredCell");
      base.Register(Object);
    }

    /* All this spawner has to do is immediately call the builder on its current
    zone and then destroy itself. */
    public override bool FireEvent(Event E)
    {
      if (E.ID == "EnteredCell")
      {
        new Gearlink_CASKOFROSEWINE_FortunadoSpawnerBuilder().BuildZone(E.GetParameter<Cell>("Cell").ParentZone);
        this.ParentObject.Destroy();
      }
      return base.FireEvent(E);
    }
  }
}
