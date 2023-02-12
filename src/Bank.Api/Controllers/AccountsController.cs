using Bank.Domain.Dtos;
using Bank.App.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bank.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountsController : ControllerBase
{
    private readonly IAccountService _accountService;

    public AccountsController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpGet]
    public IEnumerable<AccountDto> GetAll()
    {
        return _accountService.GetAll();
    }

    [HttpGet("{id}")]
    public ActionResult<AccountDto> Get(Guid id)
    {
        return Ok(_accountService.GetById(id));
    }

    [HttpPost]
    public ActionResult Add([FromBody] AccountDto accountDto)
    {
        if (accountDto is null)
        {
            return BadRequest(new ArgumentNullException());
        }

        var isCreated = _accountService.Add(accountDto);

        return isCreated ? CreatedAtAction(nameof(Add), accountDto) :
            new JsonResult(new { message = "Not Created" });

    }

    [HttpGet("{id}/balance")]
    public ActionResult<decimal> GetBalance(Guid id)
    {
        return _accountService.GetBalance(id);
    }

    [HttpGet("ids")]
    public ActionResult<IEnumerable<Guid>> GetAllIds()
    {
        return Ok(_accountService.GetAllIds());
    }

    [HttpPut("/deposit")]
    public ActionResult<IEnumerable<Guid>> Deposit(Guid accountId, decimal amount)
    {
        var success = _accountService.Deposit(accountId, amount);

        return success ? Ok(success) : NotFound(success);
    }

    [HttpPut("/withdrawel")]
    public ActionResult<IEnumerable<Guid>> Withdrawel(Guid accountId, decimal amount)
    {
        var success = _accountService.Withdrawel(accountId, amount);

        return success ? Ok(success) : NotFound(success);
    }

    [HttpDelete("{id}")]
    public void Delete(Guid id)
    {
        //TODO: 
        throw new NotImplementedException();
    }
}
