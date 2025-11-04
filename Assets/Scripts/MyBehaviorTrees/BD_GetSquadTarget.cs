using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class BD_GetSquadTarget : Action
{
    public SharedTransform target;   // variable partagée dans l’arbre

    public override TaskStatus OnUpdate()
    {
        // On récupère le comportement du drone rouge
        var controller = GetComponent<DroneRedBehavior>();
        if (controller == null)
            return TaskStatus.Failure;

        // On suppose que DroneRedBehavior possède une référence vers l’ArmyManagerRed
        var manager = FindObjectOfType<ArmyManagerRed>();
        if (manager == null)
            return TaskStatus.Failure;

        // On demande une cible au chef
        Transform t = manager.GetTargetForSquad(0); // (0 temporaire, jusqu’à implémentation des squads)
        if (t == null)
            return TaskStatus.Failure;

        // On envoie la cible dans la variable partagée
        target.Value = t;
        return TaskStatus.Success;
    }
}
