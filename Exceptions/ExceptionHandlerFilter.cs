using System;
using api.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

public class ExceptionHandlerFilter : IActionFilter, IOrderedFilter {
    public int Order { get; } = int.MaxValue - 10;

    public void OnActionExecuting(ActionExecutingContext context) { }

    public void OnActionExecuted(ActionExecutedContext context) {
        Exception e = context.Exception;

        if(e != null) {
            // 400 Bad Request
            if(e is CargoIdInvalidoException ||
                e is EmailInvalidoException ||
                e is EstadoPedidoIdInvalidaException ||
                e is MesaDoPedidoInvalidaException ||
                e is NomeInvalidoException ||
                e is PedidoIdInvalidoException ||
                e is PedidoInvalidoException ||
                e is PedidoPratoInvalidoException ||
                e is PedidoSemPratosException ||
                e is SenhaInvalidaException ||
                e is UsuarioInvalidoException ||
                e is NomeDoPratoInvalidoException ||
                e is PratoInvalidoException ||
                e is PrecoDoPratoInvalidoException
            )
                context.Result = new BadRequestObjectResult(e.Message);
            // 409 Conflict
            else if(e is EmailJaEstaEmUsoException)
                context.Result = new ConflictObjectResult(e.Message);
            // 422 Unprocessable Entity
            else if(e is PedidoIdNaoCadastradoException ||
                e is PedidoIdNaoCadastradoException ||
                e is UsuarioIdNaoCadastradoException
            )
                context.Result = new UnprocessableEntityObjectResult(e.Message);
            // 500 Internal Server Error
            else if(e is FalhaCadastroPedidoException ||
                e is FalhaCadastroUsuarioException ||
                e is FalhaCadastroPratoException
            )
                context.Result = new ObjectResult(e.Message) {
                    StatusCode = 500
                };
            // 500 Internal Server Error (Erro desconhecido)
            else
                context.Result = new ObjectResult("Ocorreu um erro desconhecido.") {
                    StatusCode = 500
                };
            context.ExceptionHandled = true;
        }
    }
}