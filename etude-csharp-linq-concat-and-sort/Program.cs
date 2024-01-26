namespace etude_csharp_linq_concat_and_sort;
class A(string foo, int bar)
{
    public string Foo { get; set; } = foo;
    public int Bar { get; set; } = bar;
}

class B(string foo, int bar)
{
    public string Foo { get; set; } = foo;
    public int Bar { get; set; } = bar;
}

class C(string foo, int bar)
{
    public string Foo { get; set; } = foo;
    public int Bar { get; set; } = bar;
}

class Program
{
    static void Main(string[] args)
    {
        IEnumerable<A> a = new List<A> { new("a", 1), new("b", 2), new("c", 3) };
        IEnumerable<B> b = new List<B> { new("d", 4), new("e", 5), new("f", 6) };

        var combinedAndSorted = a.Select(x => new C(x.Foo, x.Bar))
                                  .Concat(b.Select(x => new C(x.Foo, x.Bar)))
                                  //.Where(c => c.Bar > 3) // <- Whereで絞り込み
                                  .Where(c => c.Bar == 3 || "a".Equals(c.Foo) )
                                  .OrderBy(c => c.Bar);


        foreach (var item in combinedAndSorted)
        {
            Console.WriteLine($"Foo: {item.Foo}, Bar: {item.Bar}");
        }

    }
}
