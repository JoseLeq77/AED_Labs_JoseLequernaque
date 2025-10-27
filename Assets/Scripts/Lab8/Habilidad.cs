using UnityEngine;

public class Habilidad
{
    public string Nombre;
    public string Descripcion;
    public int NivelRequerido;
    public float Poder;

    public Habilidad(string nombre, string descripcion, int nivelRequerido, float poder)
    {
        Nombre = nombre;
        Descripcion = descripcion;
        NivelRequerido = nivelRequerido;
        Poder = poder;
    }

    public override string ToString()
    {
        return $"{Nombre} (Nivel: {NivelRequerido}, Poder: {Poder})";
    }
}