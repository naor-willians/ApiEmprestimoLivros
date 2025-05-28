using EmprestimoLivros.DataContext;
using EmprestimoLivros.Models;
using Microsoft.EntityFrameworkCore;

namespace EmprestimoLivros.Services.EmprestimoLivros

{
    public class EmprestimoService : IEmprestimoInterface
    {
        private readonly ApplicationDbContext _context;

        public EmprestimoService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel<List<EmprestimoModel>>> GetEmprestimos()
        {
            ResponseModel<List<EmprestimoModel>> serviceResponse = new ResponseModel<List<EmprestimoModel>>();

            try
            {
                serviceResponse.Dados = _context.EmprestimoLivros.ToList();

                if(serviceResponse.Dados.Count == 0)
                {
                    serviceResponse.Mensagem = "Nenhum dado encontrado";
                }

            }
            catch (Exception ex) 
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Status = false;
            }

            return serviceResponse;
        }

        public async Task<ResponseModel<List<EmprestimoModel>>> CreateEmprestimo(EmprestimoModel emprestimo)
        {
            ResponseModel<List<EmprestimoModel>> serviceResponse = new ResponseModel<List<EmprestimoModel>>();

            try
            {
                if (emprestimo == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Informe os dados!";
                    serviceResponse.Status = false;

                    return serviceResponse;
                }
                _context.Add(emprestimo);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.EmprestimoLivros.ToList();


            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Status = false;
            }

            return serviceResponse;
        }

        public async Task<ResponseModel<EmprestimoModel>> GetEmprestimoById(int id)
        {
            ResponseModel<EmprestimoModel> serviceResponse = new ResponseModel<EmprestimoModel>();

            try
            {
                EmprestimoModel emprestimo = _context.EmprestimoLivros.FirstOrDefault(x => x.Id == id);

                if (emprestimo == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Emprestimo não encontrado!";
                    serviceResponse.Status = false;
                }

                serviceResponse.Dados = emprestimo;
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Status = false;
            }
            return serviceResponse;
        }

        public async Task<ResponseModel<List<EmprestimoModel>>> UpdateEmprestimo(EmprestimoModel emprestimoEditado)
        {
            ResponseModel<List<EmprestimoModel>> serviceResponse = new ResponseModel<List<EmprestimoModel>>();

            try
            {
                EmprestimoModel emprestimo = _context.EmprestimoLivros.AsNoTracking().FirstOrDefault(x => x.Id == emprestimoEditado.Id);

                if (emprestimo == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Dados incorretos";
                    serviceResponse.Status = false;
                }

                _context.Update(emprestimoEditado);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.EmprestimoLivros.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Status = false;
            }
            return serviceResponse;
        }

        public async Task<ResponseModel<List<EmprestimoModel>>> DeleteEmprestimo(int id)
        {
            ResponseModel<List<EmprestimoModel>> serviceResponse = new ResponseModel<List<EmprestimoModel>>();

            try
            {
                EmprestimoModel emprestimo = _context.EmprestimoLivros.FirstOrDefault(x => x.Id == id);

                if (emprestimo == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Dados não encontrados";
                    serviceResponse.Status = false;

                    return serviceResponse;
                }

                _context.Remove(emprestimo);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.EmprestimoLivros.ToList();
            }
            catch (Exception ex) 
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Status= false;
            }

            return serviceResponse;
        }
    }
}
