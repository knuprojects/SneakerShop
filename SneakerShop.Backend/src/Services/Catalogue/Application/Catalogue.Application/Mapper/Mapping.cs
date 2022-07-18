using Catalogue.Application.Commands.Category.CreateCategory;
using Catalogue.Application.Commands.Category.DeleteCategory;
using Catalogue.Application.Commands.Category.UpdateCategory;
using Catalogue.Application.Commands.Companies.CreateCompany;
using Catalogue.Application.Commands.Companies.DeleteCompany;
using Catalogue.Application.Commands.Companies.UpdateCompany;
using Catalogue.Application.Commands.Sneakers.CreateSneaker;
using Catalogue.Application.Commands.Sneakers.DeleteSneaker;
using Catalogue.Application.Commands.Sneakers.UpdateSneaker;
using Catalogue.Application.Dto;
using Catalogue.Domain.Entities;

namespace Catalogue.Application.Mapper
{
    public static class Mapping
    {
        #region CompanyCommand
        public static CreateCompanyDto CreateCommandCompany(this CreateCompanyCommand createCompanyCommand)
        {
            return new CreateCompanyDto
            {
                Name = createCompanyCommand.Name,
                Deleted = createCompanyCommand.Deleted
            };
        }

        public static UpDateCompanyDto UpdateCommandCompany(this UpdateCompanyCommand updateCompanyCommand)
        {
            return new UpDateCompanyDto
            {
                CompanyId = updateCompanyCommand.CompanyId,
                Name = updateCompanyCommand.Name,
                Deleted = updateCompanyCommand.Deleted
            };
        }

        public static DeleteCompanyDto DeleteCommandCompany(this DeleteCompanyCommand deleteCompanyCommand)
        {
            return new DeleteCompanyDto
            {
                CompanyId = deleteCompanyCommand.CompanyId,
                Deleted = deleteCompanyCommand.Deleted
            };
        }
        #endregion

        #region SneakerCommand
        public static CreateSneakerDto CreateCommandSneaker(this CreateSneakerCommand createSneakerCommand)
        {
            return new CreateSneakerDto
            {
                Name = createSneakerCommand.Name,
                Price = createSneakerCommand.Price,
                Size = createSneakerCommand.Size,
                Colour = createSneakerCommand.Colour,
                PhotoUrl = createSneakerCommand.PhotoUrl,
                IsFavourite = createSneakerCommand.IsFavourite,
                Deleted = createSneakerCommand.Deleted,
                CategoryId = createSneakerCommand.CategoryId,
                CompanyId = createSneakerCommand.CompanyId
            };
        }

        public static UpDateSneakerDto UpdateCommandSneaker(this UpdateSneakerCommand updateSneakerCommand)
        {
            return new UpDateSneakerDto
            {
                SneakerId = updateSneakerCommand.SneakerId,
                Name = updateSneakerCommand.Name,
                Price = updateSneakerCommand.Price,
                Size = updateSneakerCommand.Size,
                Colour = updateSneakerCommand.Colour,
                PhotoUrl = updateSneakerCommand.PhotoUrl,
                IsFavourite = updateSneakerCommand.IsFavourite,
                Deleted = updateSneakerCommand.Deleted,
                CategoryId = updateSneakerCommand.CategoryId,
                CompanyId = updateSneakerCommand.CompanyId
            };
        }

        public static DeleteSneakerDto DeleteCommandSneaker(this DeleteSneakerCommand deleteSneakerCommand)
        {
            return new DeleteSneakerDto
            {
                SneakerId = deleteSneakerCommand.SneakerId,
                Deleted = deleteSneakerCommand.Deleted
            };
        }

        #endregion

        #region CategoryCommand

        public static CreateCategoryDto CreateCommandCategory(this CreateCategoryCommand createCategoryCommand)
        {
            return new CreateCategoryDto
            {
                Name = createCategoryCommand.Name,
                Deleted = createCategoryCommand.Deleted,
                CompanyId = createCategoryCommand.CompanyId
            };
        }

        public static DeleteCategoryDto DeleteCommandCategory(this DeleteCategoryCommand deleteCategoryCommand)
        {
            return new DeleteCategoryDto
            {
                CategoryId = deleteCategoryCommand.CategoryId,
                Deleted = deleteCategoryCommand.Deleted
            };
        }

        public static UpDateCategoryDto UpdateCommandCategory(this UpdateCategoryCommand updateCategoryCommand)
        {
            return new UpDateCategoryDto
            {
                CategoryId = updateCategoryCommand.CategoryId,
                Name = updateCategoryCommand.Name,
                Deleted = updateCategoryCommand.Deleted,
                CompanyId = updateCategoryCommand.CompanyId
            };
        }

        #endregion

        #region SneakerDto To Sneaker
        public static Sneaker CreateSneakerDtoToSneaker(this CreateSneakerDto createSneakerDto)
        {
            return new Sneaker
            {
                Name = createSneakerDto.Name,
                Price = createSneakerDto.Price,
                Size = createSneakerDto.Size,
                Colour = createSneakerDto.Colour,
                PhotoUrl = createSneakerDto.PhotoUrl,
                IsFavourite = createSneakerDto.IsFavourite,
                Deleted = createSneakerDto.Deleted,
                CategoryId = createSneakerDto.CategoryId,
                CompanyId = createSneakerDto.CompanyId
            };
        }
        #endregion
    }
}
