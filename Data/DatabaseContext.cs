using Microsoft.EntityFrameworkCore;
using api.Models;
using System;

namespace api.Data {
    public class DatabaseContext : DbContext {
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<EstadoPedido> EstadosPedido { get; set; }
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
                pedido.Property<int>(p => p.IdEstado).IsRequired();

                // TODO: testar se data nula pode ocorrer
                pedido.Property<DateTime?>(p => p.DataDoPedido).IsRequired();
            });

            builder.Entity<PedidoPrato>(pedidoPrato => {
                pedidoPrato.HasKey(pp => new { pp.IdPedido, pp.IdPrato });
            });

            builder.Entity<Prato>(prato => {
                prato.HasKey(p => p.Id);
                prato.Property<string>(p => p.Nome).IsRequired();
                prato.Property<float>(p => p.Preco).IsRequired();
            });

            builder.Entity<Usuario>(usuario => {
                usuario.HasKey(u => u.Id);
                usuario.HasIndex(u => u.Email).IsUnique();
                usuario.Property<string>(u => u.Senha).IsRequired();
                usuario.Property<string>(u => u.Nome).IsRequired();
                usuario.Property<int>(u => u.IdCargo).IsRequired();
                usuario.HasData(new Usuario[] {
                    new Usuario(1, "dono@restaurante.com", "restaurante123", "José Pereira", Cargo.DONO)
                });
            });
        }
    }
}