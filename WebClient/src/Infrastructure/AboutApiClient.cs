import ApiClient from '../ApiClient';
import License from '../../Domain/License';

class AboutApiClient extends ApiClient {
  public async getLicenses(): Promise<License[]> {
    const response = await this.get('about/licenses');
    return response.json();
  }
}

export default AboutApiClient;
