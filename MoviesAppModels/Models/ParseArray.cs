namespace MoviesAppModels.Models {
    public  class ParseArray {

         

        public string parse(string [] result, string[] StrParse) {
            result = StrParse.Select(i => i.ToString()).ToArray();
            return  String.Join(", ", result);
        }
    }
}
