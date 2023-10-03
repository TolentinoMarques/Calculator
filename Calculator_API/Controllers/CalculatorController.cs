using Microsoft.AspNetCore.Mvc;

namespace Calculator_API.Controllers;

[ApiController]
[Route("[controller]")]
public class CalculatorController : ControllerBase
{

    private readonly ILogger<CalculatorController> _logger;

    public CalculatorController(ILogger<CalculatorController> logger)
    {
        _logger = logger;
    }

    [HttpGet("sum/{firstNumber}/{secondNumber}")]
    public IActionResult Sum(string firstNumber, string secondNumber)
    {

        if (isNumeric(firstNumber) && isNumeric(secondNumber))
        {
            var sum = ConvertToDouble(firstNumber) + ConvertToDouble(secondNumber);
            return Ok(sum.ToString());
        }
       return BadRequest("Invalid Input");
    }

    [HttpGet("subtraction/{firstNumber}/{secondNumber}")]
    public IActionResult Subtraction(string firstNumber, string secondNumber)
    {

        if (isNumeric(firstNumber) && isNumeric(secondNumber))
        {
            var subtraction = ConvertToDouble(firstNumber) - ConvertToDouble(secondNumber);
            return Ok(subtraction.ToString());
        }
        return BadRequest("Invalid Input");
    }

    [HttpGet("multiplication/{firstNumber}/{secondNumber}")]
    public IActionResult Multiplication(string firstNumber, string secondNumber)
    {

        if (isNumeric(firstNumber) && isNumeric(secondNumber))
        {
            var multiplication = ConvertToDouble(firstNumber) * ConvertToDouble(secondNumber);
            return Ok(multiplication.ToString());
        }
        return BadRequest("Invalid Input");
    }

    [HttpGet("division/{firstNumber}/{secondNumber}")]
    public IActionResult Division(string firstNumber, string secondNumber)
    {

        if (isNumeric(firstNumber) && isNumeric(secondNumber))
        {
            var division = ConvertToDouble(firstNumber) / ConvertToDouble(secondNumber);
            return Ok(division.ToString());
        }
        return BadRequest("Invalid Input");
    }

    [HttpGet("squareroot/{firstNumber}")]
    public IActionResult Sqrt(string firstNumber)
    {

        if (isNumeric(firstNumber))
        {
            var sqrt = Math.Sqrt(ConvertToDouble(firstNumber));
            return Ok(sqrt.ToString());
        }
        return BadRequest("Invalid Input");
    }

    [HttpGet("average/{firstNumber}/{secondNumber}")]
    public IActionResult Average(string firstNumber, string secondNumber)
    {

        if (isNumeric(firstNumber) && isNumeric(secondNumber))
        {
            var average = ((ConvertToDouble(firstNumber)+ ConvertToDouble(secondNumber))/2);
            return Ok(average.ToString());
        }
        return BadRequest("Invalid Input");
    }

    private bool isNumeric(string strNumber)
    {
        double number;
        bool isNumber = double.TryParse(strNumber, 
            System.Globalization.NumberStyles.Any, 
            System.Globalization.NumberFormatInfo.InvariantInfo, 
            out number);
        return isNumber;
    }


    private double ConvertToDouble(string strNumber)
    {
        double number;
        if (double.TryParse(strNumber, out number))
        {
            return number;
        }
        return 0;
    }


}
