package service.remoteservices;

public class GDistanceMatrixElement {
	private GDistanceMatrixAtom distance;
	private GDistanceMatrixAtom duration;
	private String status;

	public GDistanceMatrixAtom getDistance() {
		return distance;
	}

	public void setDistance(GDistanceMatrixAtom distance) {
		this.distance = distance;
	}

	public GDistanceMatrixAtom getDuration() {
		return duration;
	}

	public void setDuration(GDistanceMatrixAtom duration) {
		this.duration = duration;
	}

	public String getStatus() {
		return status;
	}

	public void setStatus(String status) {
		this.status = status;
	}

}