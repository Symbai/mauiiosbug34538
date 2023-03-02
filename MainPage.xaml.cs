using System.Collections.ObjectModel;
using System.Security.Cryptography.X509Certificates;

namespace MauiApp4;

public partial class MainPage : ContentPage {
    public List<BlaGroupClass> Coll { get; } = new();

    public MainPage() {
        InitializeComponent();

        PopulateGroups();
        ListView1.ItemsSource = Coll;

    }

    public void PopulateGroups() {
        Dictionary<string, BlaGroupClass> gr = new() {
            { "One", new BlaGroupClass("One") { new BlaClass(Guid.NewGuid().ToString()) } },
            { "Two", new BlaGroupClass("Two") { new BlaClass(Guid.NewGuid().ToString()) } }
        };
        for (int i = 0; i < 50; i++) {
            if (i % 2 == 0)
                gr["One"].Add(new BlaClass(Guid.NewGuid().ToString()));
            else
                gr["Two"].Add(new BlaClass(Guid.NewGuid().ToString()));
        }
        foreach (var item in gr)
            Coll.Add(item.Value);

    }

}

public class BlaGroupClass : List<BlaClass> {
    public string Name { get; set; }

    public BlaGroupClass(string name) {
        Name = name;
    }
}
public class BlaClass {
    public string Name { get; set; }

    public BlaClass(string name) {
        Name = name;
    }
}

