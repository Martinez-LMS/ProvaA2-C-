using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NOMEDOPROJETO;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDataContext>();
//Configurar a política de CORS
builder.Services.AddCors(options =>
    options.AddPolicy("Acesso Total",
        configs => configs
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod())
);
builder.Services.AddCors();
var app = builder.Build();



app.MapPost("/usuario/cadastrar", ([FromBody] Usuario usuario,
    [FromServices] AppDataContext ctx) =>
{
    ctx.Usuario.Add(usuario);
    ctx.SaveChanges();
    return Results.Created("usuario cadastrado", usuario);
});

app.MapGet("/usuario/listar", ([FromServices] AppDataContext ctx) =>
{
    if (ctx.Usuario.Any())
    {
        return Results.Ok(ctx.Usuario.ToList());
    }
    return Results.NotFound("Nenhum usuario encontrada");
});

app.MapPost("/api/imc/cadastrar", ([FromBody] imc imc,
    [FromServices] AppDataContext ctx) =>
{
    ctx.imc.Add(imc);
    ctx.SaveChanges();
    return Results.Created("", imc);
});
app.MapGet("/imc/listar", ([FromServices] AppDataContext ctx) =>
{
    if (ctx.imc.Any())
    {
        return Results.Ok(ctx.imc.ToList());
    }
    return Results.NotFound("Nenhum imc encontrada");
});

app.MapGet("/imc/listar{aluno}", ([FromServices] AppDataContext ctx,[FromBody] imc imc ) =>
{   
    imc? imc = ctx.imc.Find(aluno);
    if (ctx.imc.Any())
    {
        return Results.Ok(ctx.imc.ToList());
    }
     if (imc is null)
    return Results.NotFound("Nenhum imc encontrada");
});

app.MapPut("/imc/alterar/{id}", ([FromServices] AppDataContext ctx, [FromRoute] string id) =>
{
    //Implementar a alteração do status da tarefa
    imc? imc = ctx.imc.Find(id);
    if (tarefa is null)
    {
        return Results.NotFound("imc não encontrado");
    }
    function alterar(){
        ctx.imc.Add(imc);
        if (imc == imc)
        {
            console.log "digite o peso alterado";
        
            console.log "digite o altura alterado";
        }
    }

    ctx.Tarefas.Update(imc);
    ctx.SaveChanges();
    return Results.Ok(ctx.imc.ToList());
});

app.UseCors("Acesso Total");
app.Run();