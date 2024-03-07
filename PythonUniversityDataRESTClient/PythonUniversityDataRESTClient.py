import requests

def ObtainAPIResponseDatas():
    api_url = "https://localhost:44374/UniversityData" 
    session = requests.Session()
    first_page = session.get(api_url).json()
    yield first_page["data"]
    num_pages = first_page['totlPages']

    for page in range(1, num_pages):
        next_page = session.get(api_url, params={'pageNumber': page, "perPage": 10}).json()
        yield next_page["data"]
        
def CountryMatches(source, input):
    if source["location"]["country"].lower() == input.lower():
        return True
    else :
        return False    
  
def SetScoreAsSortKey(universityData):
    return universityData["score"]

def GetBestUniversityByCountry(countryName):
    
    universityDatas = ObtainAPIResponseDatas()
    datasFilteredByCountry = filter(CountryMatches, universityDatas)
    if len(datasFilteredByCountry) == 0:
        return ""
    
    datasFilteredByCountry.sort(key=SetScoreAsSortKey)
    return datasFilteredByCountry[0]["university"]


country = input("Enter the name of a Country to search for its highest rated university. \n")
print("calculating... \n")
bestUniversity = GetBestUniversityByCountry(country)
print(f"The best university in {country} is: {bestUniversity}")




