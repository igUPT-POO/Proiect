// See https://aka.ms/new-console-template for more information

using Proiect;

Console.WriteLine("Hello, World!");


Console.WriteLine("Hello, World!");
Console.WriteLine("Hello, World!");
Console.WriteLine("Hello, World!");

var a = new HelloClass
{
    Prop1 = "aaa",
    Prop2 = 110,
    Prop3 = false
};


var b = new HelloClass
{
    Prop1 = "bbb",
    Prop2 = 210,
    Prop3 = true
};
var actions = new FileActions();
actions.WriteEntity(a);
actions.WriteEntity(b);

var state = new State()
{
    NameApp = "Test",
    HelloEntities = [a]
};
actions.SaveState(state);

var currentState = actions.ReadState();
var display = String.Join(' ', currentState.HelloEntities.Select(i => $"{i.Prop1}, {i.Prop2}\n"));
Console.WriteLine(display);

currentState.HelloEntities.AddRange([b,b,b,b]);
actions.SaveState(currentState);

currentState = actions.ReadState();
display = String.Join(char.MinValue, currentState.HelloEntities.Select(i => $"{i.Prop1}, {i.Prop2}\n"));
Console.WriteLine(display);

Console.WriteLine("Hello, World!");
Console.WriteLine("Hello, World!");
Console.WriteLine("Hello, World!");
