using DioAPI.Controllers;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TesteAPI_DIO_Camp.Data;
using TesteAPI_DIO_Camp.Models;
using Xunit;

namespace DIO_Teste
{
    public class CategoriasControllerTeste
    {
        private readonly Mock<DbSet<Categoria>> _mockSet;
        private readonly Mock<DIODbContext> _mockContext;
        private readonly Categoria _categoria;       

        public CategoriasControllerTeste()
        {
            _mockSet = new Mock<DbSet<Categoria>>();
            _mockContext = new Mock<DIODbContext>();
            _categoria = new Categoria { Id = 1, Descricao = "Teste" };

            _mockContext.Setup(m => m.Categoria).Returns(_mockSet.Object);

            _mockContext.Setup(m => m.Categoria.FindAsync(1))
                .ReturnsAsync(_categoria);

            _mockContext.Setup(m => m.SetModified(_categoria));

            _mockContext.Setup(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(1);

        }


        [Fact]
        public async Task Get_Categoria()
        {
            var service = new CategoriasController(_mockContext.Object);

            await service.GetCategoria(1);

            _mockSet.Verify(m => m.FindAsync(1),
                Times.Once());
        }



        [Fact]
        public async Task Put_Categoria()
        {
            var service = new CategoriasController(_mockContext.Object);

            await service.PutCategoria(1, _categoria);

            _mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()),
                Times.Once());
        }


        [Fact]
        public async Task Post_Categoria()
        {
            var service = new CategoriasController(_mockContext.Object);
            await service.PostCategoria(_categoria);

            _mockSet.Verify(x => x.Add(_categoria), Times.Once);
            _mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()),
                Times.Once());
        }


        [Fact]
        public async Task Delete_Categoria()
        {
            var service = new CategoriasController(_mockContext.Object);
            await service.DeleteCategoria(1);

            _mockSet.Verify(m => m.FindAsync(1),
                Times.Once);                       
            _mockSet.Verify(x => x.Remove(_categoria), Times.Once);
            _mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()),
                Times.Once());
        }



    }
}
