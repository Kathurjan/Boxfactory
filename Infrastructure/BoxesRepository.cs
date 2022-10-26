using Entities;

namespace Infrastructure;

public class BoxesRepository
{
    private BoxDbContext _boxDbContext;

    public BoxesRepository(BoxDbContext context)
    {
        _boxDbContext = context;
    }

    public List<Boxes> GetAllBoxes()
    {
        return _boxDbContext.BoxesTable.ToList();
    }

    public Boxes InsertProduct(Boxes boxes)
    {
        _boxDbContext.BoxesTable.Add(boxes);
        _boxDbContext.SaveChanges();
        return boxes;
    }
    
    // delete method by id;
    public void DeleteBoxes(int id)
    {   
        // we select the first box from the boxes table that matches the id given
        Boxes boxes = _boxDbContext.BoxesTable.First(b => b.Id == id);
        // after which its removed from the boxes table
        _boxDbContext.BoxesTable.Remove(boxes);
        // and the changes are saved
        _boxDbContext.SaveChanges();
        
    }

    public Boxes UpdateBoxes(Boxes boxUpdated)
    {

        _boxDbContext.BoxesTable.Update(boxUpdated);
        _boxDbContext.SaveChanges();
        return boxUpdated;
    }
    public void CreateDB()
    {
        _boxDbContext.Database.EnsureDeleted();
        _boxDbContext.Database.EnsureCreated();
    }
}