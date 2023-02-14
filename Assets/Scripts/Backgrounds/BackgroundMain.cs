using System.Collections.Generic;
using UnityEngine;

namespace Parallax2D.Modules.Background.Code.Behaviours
{
  public class BackgroundMain : MonoBehaviour
  {
    public bool NineImage;
    public List<BackgroundMovement> BackgroundMovements = new List<BackgroundMovement>(); 
    
    public void Construct(Transform player)
    {
      transform.position = player.position;
      
      foreach (var backgroundMovement in BackgroundMovements) 
        backgroundMovement.Construct(player, NineImage);
    }

    public void Update()
    {
      foreach (var backgroundMovement in BackgroundMovements) 
        backgroundMovement.UpdateMovement();
    }
  }
}