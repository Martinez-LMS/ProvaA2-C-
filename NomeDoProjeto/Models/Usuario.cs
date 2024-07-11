public class Usuario
{
	public int Id { get; set; }  = Guid.NewGuid().ToString();
	public string Nome { get; set; }

    public int CPF { get; set; }
	
}