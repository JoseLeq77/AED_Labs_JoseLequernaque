using UnityEngine;

public class AbilityGraphTest : MonoBehaviour
{
    void Start()
    {
        AbilityGraph graph = new AbilityGraph();

        graph.AddAbility(new Habilidad("Fireball", "Launches a ball of fire.", 2, 50));
        graph.AddAbility(new Habilidad("IceShield", "Creates a shield of ice.", 3, 30));
        graph.AddAbility(new Habilidad("Heal", "Restores health.", 1, 20));

        graph.Connect("Fireball", "IceShield");
        graph.Connect("Heal", "IceShield");

        graph.PrintAbilities();
        graph.PrintConnections();
    }
}