namespace Lab0.Models;

public class Organization
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }     // jako jeden łańcuch, a nie osobna klasa
    
    // potrzebujemy nowego cruda - nauczymy się teraz robić to na skróty. 
}