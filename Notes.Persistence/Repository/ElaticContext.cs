using Nest;

namespace Notes.Persistence.Repository;

public class ElaticContext
{
    public ElasticClient  Connection()
    {
        var node = new Uri("http://localhost:9200");
        var settings = new ConnectionSettings(node).DefaultIndex("geoip_databases");
        var client = new ElasticClient(settings);
        return client;
    }
  
}