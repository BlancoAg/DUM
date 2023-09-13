using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.IO;

public class ExcelReader : MonoBehaviour
{
    public int rowNumber;
    public int id;
    public int next_id;
    private void Start() {
        rowNumber = 0;
        // id = 0;
    }
    
    public List<string> GetCellsInRow(int rowNumber)
    {
        TextAsset file = Resources.Load<TextAsset>("Dialogues");
        List<string> cells = new List<string>();

        using (StringReader reader = new StringReader(file.text))
        {
            string line;
            int lineNumber = 0;

            while ((line = reader.ReadLine()) != null)
            {
                lineNumber++;

                if (lineNumber == rowNumber)
                {
                    cells = line.Split(',').Skip(1).ToList();
                    id = int.Parse(cells.Last());

                    rowNumber = 2;
                    return cells;

                }
            }
        }
        return cells;
        
    }
    public List<string> gestor_de_dialogo(){
        
        
        List<string> row = GetCellsInRow(id);
        // id = int.Parse(row.Last());
        return row;
    }
}
