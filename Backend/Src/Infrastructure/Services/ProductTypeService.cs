namespace Infrastructure.Services;

public class ProductTypeService(
    IProductTypeRepository productTypeRepository)
    : IProductTypeService
{
    public async Task<Result<IEnumerable<ProductTypeResponse>>> GetAllAsync()
    {
        var productTypesEntities = await productTypeRepository.GetAllAsync();
        var productTypesResponse = productTypesEntities.Select(productTypeEntity 
            => new ProductTypeResponse(
                Id: productTypeEntity.Id,
                Name: productTypeEntity.Name,
                PriceForOneKG: productTypeEntity.PriceForOneKG,
                PriceForDelivery: productTypeEntity.PriceForDelivery)).ToList();
        return Result<IEnumerable<ProductTypeResponse>>.Success(productTypesResponse, "Типы перевозимых грузов успешно получены.");
    }

    public async Task<Result<ProductTypeResponse>> GetByIdAsync(int id)
    {
        var productTypeEntity = await productTypeRepository.GetByIdAsync(id);
        if (productTypeEntity == null)
            return Result<ProductTypeResponse>.Fail("Тип перевозимого груза с данным идентификатором не найден!");

        var productTypeResponse = new ProductTypeResponse(
            Id: productTypeEntity.Id,
            Name: productTypeEntity.Name,
            PriceForOneKG: productTypeEntity.PriceForOneKG,
            PriceForDelivery: productTypeEntity.PriceForDelivery);
        return Result<ProductTypeResponse>.Success(productTypeResponse, "Тип перевозимого успешно получен.");
    }

    public async Task<Result> CreateAsync(CreateProductTypeRequest request)
    {
        var isExistByName = await productTypeRepository.IsExistByNameAsync(request.Name);
        if (isExistByName)
            return Result<string>.Fail("Тип перевозимого груза с данным названием уже существует!");

        var productTypeEntity = new ProductTypeEntity {
            Name = request.Name,
            PriceForOneKG = request.PriceForOneKG,
            PriceForDelivery = request.PriceForDelivery
        };
        await productTypeRepository.CreateAsync(productTypeEntity);
        return Result<string>.Success("Тип перевозимого груза успешно создан.");
    }

    public async Task<Result> UpdateAsync(int id, UpdateProductTypeRequest request)
    {
        var productTypeEntity = await productTypeRepository.GetByIdAsync(id);
        if (productTypeEntity == null)
            return Result<string>.Fail("Тип перевозимого груза с данным идентификатором не найден!");

        productTypeEntity.Name = request.Name;
        productTypeEntity.PriceForOneKG = request.PriceForOneKG;
        productTypeEntity.PriceForDelivery = request.PriceForDelivery;
        await productTypeRepository.UpdateAsync(productTypeEntity);
        return Result<string>.Success("Тип перевозимого груза успешно обновлён.");
    }

    public async Task<Result> DeleteAsync(int id)
    {
        var productTypeEntity = await productTypeRepository.GetByIdAsync(id);
        if (productTypeEntity == null)
            return Result<string>.Fail("Тип перевозимого груза с данным идентификатором не найден!");

        await productTypeRepository.DeleteAsync(productTypeEntity);
        return Result<string>.Success("Тип перевозимого груза успешно удалён.");
    }
}