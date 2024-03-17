using AuctionService.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuctionService.Data;

public class AuctionDbContext: DbContext
{
    public AuctionDbContext(DbContextOptions options) : base(options)
    {
    }

    // * Because the item is related to the auction, we don't need to specify it here
    public DbSet<Auction> Auctions { get; set; }
}