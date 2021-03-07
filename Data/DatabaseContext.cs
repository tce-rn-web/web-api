using Microsoft.EntityFrameworkCore;
using api.Models;
using System;

namespace api.Data {
    public class DatabaseContext : DbContext {
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoPrato> PedidosPratos { get; set; }
        public DbSet<Permissao> Permissoes { get; set; }
        public DbSet<Prato> Pratos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<UsuarioPermissao> UsuariosPermissoes { get; set; }
        public DbSet<EstadoPedido> EstadosPedido { get; set; }


        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);

            builder.Entity<EstadoPedido>(estadoPedido => {
                estadoPedido.HasKey(ep => ep.Id);
                estadoPedido.HasData(new EstadoPedido[] {
                    new EstadoPedido(1, "Cadastrado"),
                    new EstadoPedido(2, "Cancelado"),
                    new EstadoPedido(3, "Preparando"),
                    new EstadoPedido(4, "Entregue"),
                    new EstadoPedido(5, "Finalizado")
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

            builder.Entity<Permissao>(permissao => {
                permissao.HasKey(p => p.Id);
                permissao.Property<string>(p => p.Descricao).IsRequired();
                permissao.HasData(new Permissao[] {
                    // TODO: preencher com todas as permissões possíveis
                    new Permissao(1, "Cadastrar pedidos"),
                    new Permissao(2, "Cancelar pedidos"),
                    new Permissao(3, "Preparar pedidos"),
                    new Permissao(4, "Cobrar pedidos"),
                });
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
            });

            builder.Entity<UsuarioPermissao>(usuarioPermissao => {
                usuarioPermissao.HasKey(up => new { up.IdUsuario, up.IdPermissao });
            });
        }
    }
}