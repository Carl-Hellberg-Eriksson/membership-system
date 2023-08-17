class ApiClient {
    protected readonly baseUrl: string;
    private readonly shared: RequestInit;

    constructor(baseUrl: string, includeCredentials: boolean = true) {
      this.baseUrl = baseUrl.endsWith('/') ? baseUrl.substring(0, baseUrl.length - 1) : baseUrl;
  
      this.shared = {
        headers: {
          'Content-Type': 'application/json',
        },
        ...(includeCredentials && { credentials: 'include' }),
      };
    }
    
  protected get(endpoint: string): Promise<Response> {
    return fetch(`${this.baseUrl}/${endpoint}`, {
      method: 'GET',
      ...this.shared,
    });
  }
  
  protected post(endpoint: string, data: any = {}, customHeaders: Headers = new Headers()): Promise<Response> {
    customHeaders.set('Content-Type', 'application/json');
    return fetch(`${this.baseUrl}/${endpoint}`, {
      method: 'POST',
      mode: 'cors', // no-cors, *cors, same-origin
      body: JSON.stringify(data),
      ...this.shared,
      headers: customHeaders,
    });
  }

  protected del(endpoint: string): Promise<Response> {
    return fetch(`${this.baseUrl}/${endpoint}`, {
      method: 'DELETE',
      ...this.shared,
    });
  }

  protected patch(endpoint: string, data: any = {}): Promise<Response> {
    return fetch(`${this.baseUrl}/${endpoint}`, {
      method: 'PATCH',
      mode: 'cors', // no-cors, *cors, same-origin
      body: JSON.stringify(data),
      ...this.shared,
    });
  }
}

export default ApiClient;
