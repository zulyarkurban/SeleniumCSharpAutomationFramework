using System;
using System.Collections.Generic;
using System.IO;
using NPOI.SS.UserModel;
using NPOI.Util;
using NUnit.Framework;


namespace SeleniumCSharpProject.Utilities;

public class ExcelUtility
{
    private IWorkbook workBook;
    private ISheet workSheet;
    private ICell Cell;
    private string path;
    private FileStream ExcelFile;

    public ExcelUtility(string path, string sheetName) {
        this.path = path;
        try {
            // Open the Excel file
             ExcelFile = new FileStream(path, FileMode.Open, FileAccess.Read);
 
            workBook = WorkbookFactory.Create(ExcelFile);
            workSheet = workBook.GetSheet(sheetName);
        
           Assert.IsNotNull("Sheet: \""+sheetName+"\" does not exist\n");

        } catch (Exception e) {
           throw new RuntimeException(e);
        }
    }
    
    public String GetCellData(int rowNum, int colNum) {
        ICell cell;
        try {
            cell = workSheet.GetRow(rowNum).GetCell(colNum);
            String cellData = cell.ToString();
            return cellData;
        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }

 
    public List<string> GetDataArray()
    {
        
        List<string> data = new List<string>();
        for (int i = 0; i <rowCount(); i++) {
            for (int j = 0; j < columnCount(); j++) {
                String value = GetCellData(i, j);
                data.Add(value);
            }
        }
        return data;

    }

    public int GetRowNumber(List<string> allColumns,string columnName)
    {
        int rowNUm = 0;
        foreach (string column in allColumns)
        {
            if (column.Contains(columnName))
            {
                return rowNUm;
            }
            else
            {
                rowNUm++;
            }
        }
        return rowNUm;
    }

    public void UpdateColumnData(string columName,int row, string data)
    {
        int columnNo=GetRowNumber(GetDataArray(),columName);
        SetCellData(data,row,columnNo);
    }

    public void AddNewColumnAndItsData(string columnName, string cellData)
    {
        SetCellData(columnName,0,columnCount());
        SetCellData(cellData,1,columnCount()-1);

    }

    public void SetCellData(String value, int rowNum, int colNum) {
        ICell cell;
        IRow row;

        try {
            row = workSheet.GetRow(rowNum);
            cell = row.GetCell(colNum);

            if (cell == null) {
                cell = row.CreateCell(colNum);
                cell.SetCellValue(value);
            } else {
                cell.SetCellValue(value);
            }

            FileStream fileOut=new FileStream(path, FileMode.Create, FileAccess.Write);
            workBook.Write(fileOut);

           fileOut.Close();
           
        } catch (Exception e) {
           Console.WriteLine(e.Message);
        }
    }
    public void SetCellData(String value, String columnName, int row) {
        int column = GetColumnsNames().IndexOf(columnName);
        SetCellData(value, row, column);
    }
    
    public List<string> GetColumnsNames() {
      
        List<string> columns = new List<string>();

        foreach (ICell cell in workSheet.GetRow(0))
        {
            columns.Add(cell.ToString());
        }
        return columns;
    }
    
    public int columnCount() {
        return workSheet.GetRow(0).LastCellNum;
    }
    public int rowCount() {
        return workSheet.LastRowNum+1;
    }
}