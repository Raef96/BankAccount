using Bank.Domain.Dtos;
using Bank.App.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bank.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TransactionsController : ControllerBase
{
    private readonly ITransactionService _transactionService;

    public TransactionsController(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<TransactionDto>> Get()
    {
        return Ok(_transactionService.GetAllTransactions());
    }

    [HttpGet("/{accountId}")]
    public ActionResult<IEnumerable<TransactionDto>> GetByAccountId(Guid accountId)
    {
        return Ok(_transactionService.GetByAccountId(accountId));
    }
}
