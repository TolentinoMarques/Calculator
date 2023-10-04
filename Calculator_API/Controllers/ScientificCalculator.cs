using Microsoft.AspNetCore.Mvc;

namespace Calculator_API.Controllers;

[ApiController]
[Route("[controller]")]
public class ScientificCalculator : ControllerBase
{

    private readonly ILogger<ScientificCalculator> _logger;

    public ScientificCalculator(ILogger<ScientificCalculator> logger)
    {
        _logger = logger;
    }

    [HttpGet("log10/{firstNumber}")]
    public IActionResult log10(string firstNumber)
    {

        if (isNumeric(firstNumber))
        {
            var log10 = Math.Log10(ConvertToDouble(firstNumber));
            return Ok(log10.ToString());
        }
       return BadRequest("Invalid Input");
    }

    [HttpGet("log2/{firstNumber}")]
    public IActionResult Sum(string firstNumber)
    {

        if (isNumeric(firstNumber))
        {
            var sum = Math.Log10(ConvertToDouble(firstNumber));
            return Ok(sum.ToString());
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
