package service.remoteservices;

/**
 * @author Indrit Zeqiri
 * @Github https://github.com/ilstarno
 * @Linkedin https://www.linkedin.com/in/indrit-zeqiris-3b6b8ba6/
 */
public class GDistanceMatrixResponse {
	private String[] destination_addresses;
	private String[] origin_addresses;
	private GDistanceMatrixRow[] rows;
	private String status;

	public String[] getDestinationAddresses() {
		return destination_addresses;
	}

	public void setDestinationAddresses(String[] destination_addresses) {
		this.destination_addresses = destination_addresses;
	}

	public String[] getOriginAddresses() {
		return origin_addresses;
	}

	public void setOriginAddresses(String[] origin_addresses) {
		this.origin_addresses = origin_addresses;
	}

	public GDistanceMatrixRow[] getRows() {
		return rows;
	}

	public void setRows(GDistanceMatrixRow[] rows) {
		this.rows = rows;
	}

	public String getStatus() {
		return status;
	}

	public void setStatus(String status) {
		this.status = status;
	}

}
