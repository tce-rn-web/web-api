using Microsoft.EntityFrameworkCore;
using api.Models;
using System;

namespace api.Data {
    public class DatabaseContext : DbContext {
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<EstadoPedido> EstadosPedidos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoPrato> PedidosPratos { get; set; }
        public DbSet<Prato> Pratos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);            

            builder.Entity<Cargo>(cargo => {
                cargo.HasKey(p => p.Id);
                cargo.Property<string>(p => p.Descricao).IsRequired();
                cargo.HasData(new Cargo[] {
                    new Cargo(Cargo.DONO, "Dono"),
                    new Cargo(Cargo.FUNCIONARIO, "Funcionário")
                });
            });

            builder.Entity<EstadoPedido>(estadoPedido => {
                estadoPedido.HasKey(ep => ep.Id);
                estadoPedido.Property<string>(ep => ep.Nome).IsRequired();
                estadoPedido.HasData(new EstadoPedido[] {
                    new EstadoPedido(1, "Cadastrado"),
                    new EstadoPedido(2, "Cancelado"),
                    new EstadoPedido(3, "Preparando"),
                    new EstadoPedido(4, "Preparado"),
                    new EstadoPedido(5, "Entregando"),
                    new EstadoPedido(6, "Entregue"),
                    new EstadoPedido(7, "Finalizado")
                });
            });

            builder.Entity<Pedido>(pedido => {
                pedido.HasKey(p => p.Id);
                pedido.Property<string>(p => p.Mesa).IsRequired();
                pedido.Property<string>(p => p.Descricao).IsRequired();
                // TODO: testar se data nula pode ocorrer
                pedido.Property<DateTime?>(p => p.DataDoPedido).IsRequired();
                
                // relacionamento EstadoPedido One2Many Pedido
                pedido.HasOne<EstadoPedido>(p => p.EstadoPedido)
                    .WithMany(ep => ep.Pedidos)
                    .HasForeignKey(p => p.EstadoPedidoId)
                    .OnDelete(DeleteBehavior.Restrict);

                // REMOVER: manter por enquanto não são implementadas as operações sobre pratos
                pedido.HasData(new Pedido[] {
                    new Pedido(1, "A2", "", 1, DateTime.Now),
                    new Pedido(2, "A2", "", 1, DateTime.Now),
                    new Pedido(3, "A2", "", 1, DateTime.Now)
                });
            });

            builder.Entity<Prato>(prato => {
                prato.HasKey(p => p.Id);
                prato.Property<string>(p => p.Nome).IsRequired();
                prato.Property<float>(p => p.Preco).IsRequired();

                // REMOVER: manter por enquanto não são implementadas as operações sobre pratos
                prato.HasData(new Prato[] {
                    new Prato(1, "Açaí Tradicional 1L", 20.0f),
                    new Prato(2, "Açaí Tradicional 500ml", 10.0f),
                    new Prato(3, "Açaí Tradicional 250ml", 5.0f),
                    new Prato(4, "Açaí com Creme de Cupuaçu 1L", 20.0f),
                    new Prato(5, "Açaí com Creme de Cupuaçu 500ml", 10.0f),
                    new Prato(6, "Açaí com Creme de Cupuaçu 250ml", 5.0f),
                    new Prato(7, "Açaí com Creme de Ninho 1L", 20.0f),
                    new Prato(8, "Açaí com Creme de Ninho 500ml", 10.0f),
                    new Prato(9, "Açaí com Creme de Ninho 250ml", 5.0f),
                    new Prato(10, "Guaraná do Amazonas 1L", 10.0f),
                    new Prato(11, "Guaraná do Amazonas 500ml", 5.0f)
                });
            });

            builder.Entity<PedidoPrato>(pedidoPrato => {
                pedidoPrato.HasKey(pp => new { pp.PedidoId, pp.PratoId });
                pedidoPrato.Property<int>(pp => pp.Quantidade).IsRequired();

                // relacionamento Pedido One2Many PedidoPrato
                pedidoPrato.HasOne<Pedido>(pp => pp.Pedido)
                    .WithMany(p => p.PedidosPratos)
                    .HasForeignKey(pp => pp.PedidoId)
                    .OnDelete(DeleteBehavior.Restrict);

                // relacionamento Prato One2Many PedidoPrato
                pedidoPrato.HasOne<Prato>(pp => pp.Prato)
                    .WithMany(p => p.PedidosPratos)
                    .HasForeignKey(pp => pp.PratoId)
                    .OnDelete(DeleteBehavior.Restrict);

                pedidoPrato.HasData(new PedidoPrato[] {
                    new PedidoPrato(1,2,1),
                    new PedidoPrato(1,5,1),
                    new PedidoPrato(1,8,1),
                    new PedidoPrato(2,1,2),
                    new PedidoPrato(2,4,3),
                    new PedidoPrato(2,7,4),
                    new PedidoPrato(3,10,4)
                });
            });

            builder.Entity<Usuario>(usuario => {
                usuario.HasKey(u => u.Id);
                usuario.HasIndex(u => u.Email).IsUnique();
                usuario.Property<string>(u => u.Senha).IsRequired();
                usuario.Property<string>(u => u.Nome).IsRequired();
                
                // relacionamento Cargo One2Many Usuario 
                usuario.HasOne<Cargo>(u => u.Cargo)
                    .WithMany(c => c.Usuarios)
                    .HasForeignKey(u => u.CargoId)
                    .OnDelete(DeleteBehavior.Restrict);
                usuario.HasData(new Usuario[] {
                    new Usuario(1, "dono@restaurante.com", "restaurante123", "José Pereira", Cargo.DONO)
                });
            });
        }
    }
}