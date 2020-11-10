using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Mirror;

public class playerspawnsystem : NetworkBehaviour
{
      public GameObject player1;
     public GameObject player2;
     public Transform spawnposition1;
     public Transform spawnposition2;
    //    Start is called before the first frame update
    //  [ServerCallback]
    // private void blip()=> network.
    public override void OnStartServer() => network.OnServerReadied += spawnplayerone;
    
    public void spawnplayerone(NetworkConnection conn)
      {
  GameObject Playerone = Instantiate(player1, spawnposition1.position, Quaternion.identity);
        NetworkServer.Spawn(Playerone, conn);
     }

       public void spawnplayertwo(NetworkConnection conn)
      {
   GameObject PlayerTwo =    Instantiate(player2, spawnposition2.position, spawnposition2.rotation);
        NetworkServer.Spawn(PlayerTwo, conn);
     }
 //   [SerializeField] private GameObject PlayerPrefab = null;

 //   private static List<Transform> spawnpoints = new List<Transform>();
 //   private int nextindex = 0;

  //  public static void AddSpawnPoint(Transform transform)
  //  {
  //      spawnpoints.Add(transform);
   //     spawnpoints = spawnpoints.OrderBy(x => x.GetSiblingIndex()).ToList();
  //  }
  //  public static void RemoveSpawnPoint(Transform transform) => spawnpoints.Remove(transform);
  //  public override void OnStartServer() => network.OnServerReadied += spawnPlayer;

  //  [ServerCallback]
  //  private void OnDestroy() => network.OnServerReadied -= spawnPlayer;
  // [Server]
  // public void spawnPlayer(NetworkConnection conn)
  //  {
   //     Transform spawnPoint = spawnpoints.ElementAtOrDefault(nextindex);

    //    if(spawnpoints == null)
    //    {
     //       Debug.LogError("missing spawn pint");
     //       return;
      //  }
      //  GameObject playerInstance = Instantiate(PlayerPrefab, spawnpoints[nextindex].position, spawnpoints[nextindex].rotation);
       // NetworkServer.Spawn(playerInstance, conn);

     //   nextindex++;
  //  }
}
