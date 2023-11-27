namespace CardApp.Services;

public class EnmascararCreditCard
{

    public static string EnmascararTexto(string textoOriginal)
    {
        if (textoOriginal.Length <= 6) 
        {
            return textoOriginal; 
        }
        else
        {
            string primerosDos = textoOriginal.Substring(0, 2);

            string ultimosCuatro = textoOriginal.Substring(textoOriginal.Length - 4);

            int caracteresAEnmascarar = textoOriginal.Length - (primerosDos.Length + ultimosCuatro.Length);

            string caracteresEnmascarados = new string('*', caracteresAEnmascarar);

            string textoEnmascarado = $"{primerosDos}{caracteresEnmascarados}{ultimosCuatro}";

            return textoEnmascarado;
        }
    }

}
