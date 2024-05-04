using System;

// Corregir el orden de las declaraciones: Las instrucciones de nivel superior deben ir antes del espacio de nombres
public class Job
{
    private string _company;
    private string _jobTitle;
    private int _startYear;
    private int _endYear;

    // Constructor de la clase
    public Job(string company, string jobTitle, int startYear, int endYear)
    {
        _company = company;
        _jobTitle = jobTitle;
        _startYear = startYear;
        _endYear = endYear;
    }

    // Método para mostrar los detalles del trabajo
    public void DisplayJobDetails()
    {
        Console.WriteLine($"{_jobTitle} ({_company}) {_startYear}-{_endYear}");
    }
}

