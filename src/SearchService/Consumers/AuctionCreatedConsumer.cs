using AutoMapper;
using Contracts;
using MassTransit;
using MongoDB.Entities;
using SearchService.Models;

namespace SearchService.Consumers;

public class AuctionCreatedConsumer : IConsumer<AuctionCreated>
{
    private readonly IMapper _mapper;

    public AuctionCreatedConsumer(IMapper mapper)
    {
        _mapper = mapper;
    }
    
    public async Task Consume(ConsumeContext<AuctionCreated> context)
    {
        Console.WriteLine("---> Consuming Auction created" + context.Message.Id);

        var items = _mapper.Map<Item>(context.Message);

        if (items.Model == " foo")
        {
            throw new ArgumentException("Cannot sell a car named Foo");
        }
        
        await items.SaveAsync();
    }
}