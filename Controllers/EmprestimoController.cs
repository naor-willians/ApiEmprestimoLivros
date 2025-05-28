using EmprestimoLivros.Models;
using EmprestimoLivros.Services.EmprestimoLivros;
using Microsoft.AspNetCore.Mvc;

namespace EmprestimoLivros.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EmprestimoController : ControllerBase
    {
        private readonly IEmprestimoInterface _emprestimoInterface;

        public EmprestimoController(IEmprestimoInterface emprestimoInterface)
        {
            _emprestimoInterface = emprestimoInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseModel<List<EmprestimoModel>>>> GetEmpretimos()
        {
            return Ok(await _emprestimoInterface.GetEmprestimos());
        }

        [HttpPost]
        public async Task<ActionResult<ResponseModel<List<EmprestimoModel>>>> CreateEmprestimo(EmprestimoModel emprestimo)
        {
            return Ok(await _emprestimoInterface.CreateEmprestimo(emprestimo));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseModel<EmprestimoModel>>> GetEmprestimoById(int id)
        {
            return Ok(await _emprestimoInterface.GetEmprestimoById(id));
        }

        [HttpPut]
        public async Task<ActionResult<ResponseModel<List<EmprestimoModel>>>> UpdateEmprestimo(EmprestimoModel emprestimo)
        {
            return Ok(await _emprestimoInterface.UpdateEmprestimo(emprestimo));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseModel<List<EmprestimoModel>>>> DeleteEmprestimo(int id)
        {
            return Ok(await _emprestimoInterface.DeleteEmprestimo(id));
        }

    }
}
