import requests

#This function makes a GET request to the API provided in the instructions, and returns an iterable containing all of the items in each page's "data" lists.
def ObtainAPIResponseDatas():
    api_url = "https://localhost:44374/UniversityData?pageNumber=0&perPage=10" 
    session = requests.Session()
    
    #Instructions did not specify whether or not the client's request would be verified by server, dropping verification in this case.
    first_page = session.get(api_url, verify = False).json()
    total_Items = first_page['total']
    per_page = first_page["per_page"]
    total_pages = first_page["total_pages"]
    
    if total_Items > per_page:
        university_datas = []
        university_datas.extend(first_page["data"])      
        
        for page in range(1, total_pages):
            api_url = f"https://localhost:44374/UniversityData?pageNumber={page}&perPage=10" 
            next_page = session.get(api_url).json()
            university_datas.extend(next_page["data"])       
            
        return university_datas
    
    else:
        return first_page["data"]
        
def FilterForCountryMatches(university_datas, country):
    """
         Loops through university data objects from API Response, returns list with only objects that are correlated to the same country passed in by the user.
        
        Args: 
            university_data (iterable): collection of objects representing universities and their additional data.
            
        returns: 
            int: the score associated with the data record.
    """
    country_matches = [] 
    
    for data in list(university_datas):
        if(data["location"]["country"].lower() == country.lower()):
            country_matches.append(data)
            
    return country_matches    

def SetScoreAsSortKey(university_data):
    ' ' 'Returns "score" property from argument object, (int) ' ' '
    return university_data["score"]

def bestUniversityByCountry(country_name):
    """
         Obtains a data set of universities and their additional data, filters the data set down to objects that contain the "country_name" search parameter, and returns the highest rated university in the filtered set.
        
        Args: 
            country_name (string): the name of the country in which we are searching for the top rated university.
            
        returns: 
            string: the name of the university. If none found for passed in country, returns enty string.
    """
    university_datas = ObtainAPIResponseDatas()
    
    datas_filtered_by_country = FilterForCountryMatches(university_datas, country)
    
    if len(list(datas_filtered_by_country)) == 0:
        return ""
    
    datas_filtered_by_country.sort(reverse= True, key= SetScoreAsSortKey)
    return datas_filtered_by_country[0]["university"]


if __name__ == '__main__':
    
    #Obtain country search parameter from console, pass it into bestUniversityByCountry() as our country search parameter.
    country = input("")
    result = bestUniversityByCountry(country)
    # Print best university's name based on score, in provided country, to console. If none found, function returns empty string.
    print(result)      


        



