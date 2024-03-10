namespace PriorityQueue;

public class Item{
    private int pri;
    private string data;

    public Item(int p, string d) {
        pri = p;
        data = d;
    }
    public override string ToString()
    {
        return $"({pri}, {data})";
    }
    public int getPri() {
        return pri;
    }
}



public class PriQueue{
    private List<Item> items = new List<Item>();
    public class EmptyPriQueueException : Exception { };

    public void Add(Item t){
        items.Add(t);
    }
    public int GetLength(){
        return items.Count;
    }

    public Item RemoveMax(){
        if(items.Count == 0) throw new EmptyPriQueueException();
        int highestInd = GetHighestInd();
        Item t = items[highestInd];
        items.RemoveAt(highestInd);
        return t;
    }
    public Item GetMax(){
        if(items.Count == 0) throw new EmptyPriQueueException();
        int highestInd = GetHighestInd();
        return items[highestInd];
    }

    private int GetHighestInd(){
        int ind = 0;
        int hp = items[0].getPri();
        for(int i= 1 ; i < items.Count ;i++ ){
            if( hp < items[i].getPri()){
                ind = i ;
                hp = items[i].getPri();
            }
        }
        return ind;
    }

    public bool IsEmpty(){
        return items.Count == 0;
    }

    public override string ToString(){
        string output = "";
        for(int i = 0; i < items.Count ; i++){
            output += items[i]+"\n";
        }
        return output;
    }

}